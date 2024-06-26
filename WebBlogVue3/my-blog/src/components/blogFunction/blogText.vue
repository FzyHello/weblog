<template>
  <div class="blog-info-article">
    <div class="blog-info-article-title">最近更新</div>
    <div class="blog-info-article-content">
      <div
        class="blog-info-article-content-item"
        v-for="item in textList"
        :key="item.name"
      >
        {{ item.name }}
      </div>
    </div>
  </div>
</template>

<script setup name="blogText">
const props = defineProps({
  textList: {
    type: Array,
    default: () => [],
  },
});
</script>

<style lang="scss" scoped>
.blog-info-article {
  margin-top: 20px;
  padding: 10px;
  &-title {
    font-size: 13px;
    color: #333;
    opacity: 0.6;
  }
  &-content {
    height: 100%;
    margin-top: 10px;
    &-item {
      padding: 8px;
      color: #333;
      font-size: 14px;
      border-radius: 8px;
    }
    &-item:hover {
      transition: all 0.5s ease 0s;
      background-color: #fff;
    }
  }
}
</style>
