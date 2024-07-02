<template>
  <div class="blog">
    <div
      class="blog-item"
      v-for="item in textList"
      :key="item.title"
      @click="showText()"
    >
      <img
        class="blog-item-img"
        :src="imageUrl"
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
</template>

<script setup>
import { reactive } from "vue";
import { Post } from "@/service/baseService.ts";
      const apiKey = '4df2ba3a98dd15521de2acdd8c8de015.8wC4lcuF1e2W9624';
      const url = 'https://open.bigmodel.cn/api/paas/v4/images/generations';
      const data = {
        model: 'cogview-3',
        prompt: "一只可爱的小猫咪",
      };
const textList = reactive([{
  title: "222",
        content: "222",
        date: "222",
        author: "222"
}]);
const myHeaders = {
  'Authorization': '4df2ba3a98dd15521de2acdd8c8de015.8wC4lcuF1e2W9624',
  'Custom-Header': 'custom_value',
};
const imageUrl =  '';
const sendPostRequest = async () => {
  try {
    const response = await Post("http://localhost:5214/Article/article");
    for (let i = 0; i < response.length; i++) {
      textList.push({
        title: response[i].article_Title,
        content: response[i].article_Content,
        date: response[i].create_Time,
        author: response[i].article_Type
      });
    }
    const response2 = await Post(url, data,myHeaders);
      console.log(response2.data);
      //console.log(response2);
      imageUrl = response2.data.url;
  } catch (error) {
    console.error(error);
  }
};

sendPostRequest();
</script>

<style lang="scss" scoped>
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
