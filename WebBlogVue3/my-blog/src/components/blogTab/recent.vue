<template>
  <div class="blogs">
    <div v-if="selectedItem.title !== ''" class="blogs-detail">
      <div class="blogs-detail-header">
        <div class="blogs-detail-header-info">
          <span>主页/文章/ {{ selectedItem.author }}</span>
          <div class="blogs-detail-header-title">{{ selectedItem.title }}</div>
          <div class="blogs-detail-header-details">
            <span>日期: {{ selectedItem.date }}</span>
          </div>
        </div>
      </div>
      <div class="blogs-detail-box">
        <span>日期: {{ selectedItem.date }}</span>
      </div>
    </div>
    <div v-else>
      <div
        class="blog-item"
        v-for="item in textList"
        :key="item.title"
        @click="showText(item)"
      >
        <img
          class="blog-item-img"
          src="https://fuss10.elemecdn.com/e/5d/4a731a90594a4af544c0c25941171jpeg.jpeg"
          alt="Your Image"
        />
        <div class="blog-item-box">
          <div class="blog-item-box-title">{{ item.title }}</div>
          <div class="blog-item-box-content">{{ item.content }}</div>
          <div class="blog-item-box-author">
            <el-icon><Calendar /></el-icon><span>{{ item.date }}</span>
            <el-icon style="margin-left: 10px"><Collection /></el-icon
            ><span>{{ item.author }}</span>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script setup>
import { reactive } from "vue";
import { Post } from "@/service/baseService.ts";



const selectedItem = reactive({
  title: '',
  content: '',
  date: '',
  author: ''
}); // 用于存储选中的文章详情项

const showText = (item) => {
  selectedItem.title = item.title;
  selectedItem.content = item.content;
  selectedItem.date = item.date;
  selectedItem.author = item.author;

  // 清空文章列表
  textList.splice(0, textList.length);
};

const textList = reactive([]);

const sendPostRequest = async () => {
  try {
    const response = await Post('http://localhost:5214/Article/article');
    for (let i = 0; i < response.length; i++) {
      textList.push({
        title: response[i].article_Title,
        content: response[i].article_Content,
        date: response[i].create_Time,
        author: response[i].article_Type
      });
    }
  } catch (error) {
    console.error(error);
  }
};

sendPostRequest();
</script>

<style lang="scss" scoped>
.blogs {
  &-detail {
    width: 100%;
    border-radius: 10px;
    margin-bottom: 20px;
    cursor: pointer;

    &-header {
      background-color: #b2bad6;
      border-radius: 10px;
      padding: 10px;
      border-bottom: 1px solid #ddd;

      &-info {
        display: flex;
        flex-direction: column;
      }

      &-title {
        font-size: 24px;
        font-weight: bold;
        margin-bottom: 5px;
      }

      &-details {
        font-size: 14px;
        color: #777;
      }
    }

    &-img {
      width: 100%;
      height: auto;
      display: block;
    }

    &-box {
      padding: 15px;

      &-content {
        font-size: 16px;
        line-height: 1.5;
      }
    }
  }
}
.blog {
  height: 100%;
  &-item {
    border: 1px solid #ccc;
    width: 100%;
    border-radius: 10px;
    margin-bottom: 20px;
    cursor: pointer;
    &-img {
      border-radius: 10px 10px 0 0;
      object-fit: cover;
      width: 100%;
      height: 150px;
    }
    &-box {
      padding: 10px;
      &-title {
        font-size: 18px;
        font-weight: 600;
        color: #252933;
      }
      &-content {
        margin: 10px 0;
        font-size: 14px;
        color: #8a919f;
        display: -webkit-box;
        -webkit-line-clamp: 2; /* 控制显示的行数 */
        -webkit-box-orient: vertical;
        overflow: hidden;
      }
      &-author {
        display: flex;
        align-items: center;
        font-size: 14px;
        color: #8a919f;
        gap: 5px;
      }
    }
  }
}
</style>