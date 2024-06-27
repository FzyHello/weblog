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
</template>

<script setup>
import { reactive } from "vue";

const textList = reactive([
  {
    title: "Vue2+element ui+webpack",
    content:
      "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容",
    date: "2024-04-24",
    author: "前端",
  },
  {
    title: "Vue2+element ui+webpack",
    content:
      "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容",
    date: "2024-04-24",
    author: "前端",
  },
  {
    title: "Vue2+element ui+webpack",
    content:
      "内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容内容",
    date: "2024-04-24",
    author: "前端",
  },
]);
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
