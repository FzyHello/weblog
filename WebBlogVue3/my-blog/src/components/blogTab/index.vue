<template>
  <div class="blog-content">
    <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
      <el-tab-pane label="近期发布" name="first">
        <recent></recent>
      </el-tab-pane>
      <el-tab-pane label="分类" name="second">分类</el-tab-pane>
      <el-tab-pane label="标签" name="third">标签</el-tab-pane>
      <el-tab-pane label="归档" name="fourth">归档</el-tab-pane>
    </el-tabs>
  </div>
</template>

<script setup name="blogTab">
import { ref } from "vue";
import recent from "./recent.vue";

const activeName = ref("first");

function handleClick(tab) {
  console.log(tab);
}
</script>

<style lang="scss" scoped>
.blog-content {
  height: 100%;
  padding: 0 30px;
}
</style>
