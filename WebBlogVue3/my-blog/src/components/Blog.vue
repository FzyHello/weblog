<template>
  <div class="blog">
    <el-row :span="24">
      <el-col :span="4"></el-col>
      <el-col :span="16">
        <el-row :span="24" class="blog-row">
          <el-col :span="6">
            <div class="blog-info">
              <!-- 个人信息 -->
              <div class="blog-info-top">
                <el-row :gutter="30">
                  <el-col :span="5">
                    <el-avatar :size="40" :src="circleUrl"
                  /></el-col>
                  <el-col :span="19">
                    <div class="blog-info-top-nameBox">
                      <div class="blog-info-top-nameBox-name">Aimer</div>
                      <div class="blog-info-top-nameBox-role">个人博客</div>
                    </div></el-col
                  >
                </el-row>
              </div>
              <!-- 发布 -->
              <div class="blog-info-use">
                <el-row>
                  <el-button type="primary" class="blog-info-use-btn"
                    >发布文章</el-button
                  >
                </el-row>
              </div>
              <!-- 搜索 -->
              <div class="blog-info-search">
                <el-row>
                  <el-input
                    v-model="searchInfo"
                    placeholder="站内搜索"
                    :prefix-icon="Search"
                  />
                </el-row>
              </div>
              <!-- 功能按钮 -->
              <div class="blog-info-function">
                <el-button :icon="Edit" @click="showComponent('Edit')" />
                <el-button :icon="Share" @click="showComponent('Share')" />
                <el-button :icon="Delete" @click="showComponent('Delete')" />
                <el-button :icon="Service" @click="showComponent('Service')" />
              </div>
              <!-- 功能展示 -->
              <BlogText
                v-show="currentComponent === 'Edit'"
                :textList="textList"
              ></BlogText>
              <blogServer v-show="currentComponent === 'Share'"></blogServer>
              <blogSearch v-show="currentComponent === 'Service'"></blogSearch>
              <blogDel v-show="currentComponent === 'Delete'"></blogDel>
            </div>
          </el-col>
          <el-col :span="18">
            <!-- 文章Tab -->
            <blogTab></blogTab>
          </el-col>
        </el-row>
      </el-col>
      <el-col :span="4"></el-col>
    </el-row>
  </div>
</template>

<script setup name="Blog">
import { Search, Edit, Share, Delete, Service } from "@element-plus/icons-vue";
import { ref, reactive, defineComponent } from "vue";
import BlogText from "@/components/blogFunction/blogText.vue";
import blogServer from "@/components/blogFunction/blogServer.vue";
import blogSearch from "@/components/blogFunction/blogSearch.vue";
import blogDel from "@/components/blogFunction/blogDel.vue";
import blogTab from "@/components/blogTab/index.vue";

// 头像
const circleUrl = ref("");
// 搜索
let searchInfo = ref("");
let currentComponent = ref("Edit");
let textList = reactive([
  {
    name: "vue2+element ui+webpack",
  },
  {
    name: "vue3+element plus+vite",
  },
]);

function showComponent(value) {
  currentComponent.value = value;
}
</script>

<style lang="scss" scoped>
.blog {
  margin-top: 10px;
  &-row {
    flex: 1;
    height: 100%;
  }
  &-info {
    height: calc(100% - 20px);
    width: calc(100% / 6);
    position: fixed;
    padding: 20px 10px;
    background-image: linear-gradient(#e9e9e5, #b9bcb3 100%);
    backdrop-filter: blur(10px) brightness(90%);
    background-color: rgba(255, 255, 255, 0.5);
    border-radius: 10px;
    &-top {
      height: 50px;
      &-nameBox {
        height: 50px;
        margin-left: 10px;
        display: flex;
        flex-direction: column;
        &-name {
          font-size: 18px;
          font-weight: 700;
        }
        &-role {
          font-size: 12px;
          color: #4d4d4c;
        }
      }
    }
    &-use {
      margin-top: 10px;
      &-btn {
        width: 100%;
      }
    }
    &-search {
      margin-top: 10px;
    }
    &-function {
      margin: 10px 0;
      display: flex;
      flex-wrap: wrap;
      justify-content: space-between;
      align-items: center;
      .el-button + .el-button {
        margin-left: 0;
      }
    }
  }
}
</style>
