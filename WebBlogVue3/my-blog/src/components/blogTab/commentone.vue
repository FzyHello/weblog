<template>
    <div class="comment-item">
      <p>{{ comment.content }}</p>
      <button @click="showReplyForm">回复</button>
    </div>
  </template>
  
  <script>
  export default {
    props: {
      comment: {
        type: Object,
        required: true
      }
    },
    methods: {
      showReplyForm() {
        this.$emit('show-reply-form');
      }
    }
  };
  </script>
  
  <style scoped>
  /* 样式可以根据实际需求进行自定义 */
  .comment-item {
    margin-bottom: 10px;
    border: 1px solid #ccc;
    padding: 10px;
  }
  </style>