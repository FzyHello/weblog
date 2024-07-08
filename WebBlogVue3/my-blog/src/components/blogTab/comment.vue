<template>
    <div class="comment-list">
      <h2>评论列表</h2>
      <ul class="comments">
        <li v-for="comment in comments" :key="comment.id" class="comment-item">
          <!-- 用户信息 -->
          <div class="user-info">
            <img src="../../assets/img/xiongmao.png" alt="User Avatar" class="avatar1">
            <span class="username">{{ comment.user.nickname }}</span>
            <span class="comment-time">{{ formatTime(comment.user.time) }}</span>
          </div>
  
          <!-- 评论内容 -->
          <div class="comment-content">
            <p>{{ comment.content }}</p>
            <div class="comment-actions">
              <button class="reply-button" @click="showReplyForm(comment.id)">回复</button>
            </div>
          </div>
  
          <!-- 回复表单 -->
          <div v-if="replyTo === comment.id" class="reply-form">
            <textarea v-model="replyContent" placeholder="请输入回复内容"></textarea>
            <div class="reply-actions">
              <button class="post-reply-button" @click="postReply(comment.id)">发表回复</button>
            </div>
          </div>
  
          <!-- 显示回复列表 -->
          <ul v-if="comment.replies.length > 0" class="comment-replies">
            <p v-for="reply in comment.replies" :key="reply.id" class="comment-item">
              <!-- 用户信息 -->
              <div class="user-info">
                <img src="../../assets/img/xiongmao.png" alt="User Avatar" class="avatar2">
                <span class="username">{{ reply.user.nickname }}</span>
                <span class="comment-time">{{ formatTime(comment.user.time) }}</span>
              </div>
  
              <!-- 回复内容 -->
              <div class="comment-content">
                <p>{{ reply.content }}</p>
              </div>
            </p>
          </ul>
        </li>
      </ul>
  
      <!-- 发表评论表单 -->
      <div class="new-comment-form">
        <textarea v-model="newComment" placeholder="请输入评论内容"></textarea>
        <div class="new-comment-actions">
          <button class="post-comment-button" @click="postComment">发表评论</button>
        </div>
      </div>
    </div>
  </template>
  
  <script>
  import CommentItem from '@/components/blogTab/commentone.vue';
  
  export default {
    components: {
      CommentItem
    },
    data() {
      return {
        comments: [
          {
            id: 1,
            content: '这是第一条评论',
            user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: '2024-07-08 10:00' },
            replies: [
              { id: 101, content: '第一条评论的回复1', user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: '2024-07-08 10:05:30' } },
              { id: 102, content: '第一条评论的回复2', user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: '2024-07-08 10:05:30' } }
            ]
          },
          {
            id: 2,
            content: '这是第二条评论',
            user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: '2024-07-08 10:05:30' },
            replies: []
          }
        ],
        newComment: '',
        replyContent: '',
        replyTo: null
      };
    },
    methods: {
      postComment() {
        // 模拟向后端发送评论请求，并将新评论添加到列表中
        const newId = this.comments.length + 1;
        this.comments.push({
          id: newId,
          content: this.newComment,
          user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: new Date().toLocaleString() },
          replies: []
        });
        this.newComment = '';
      },
      showReplyForm(commentId) {
        this.replyTo = commentId;
        this.replyContent = '';
      },
      postReply(commentId) {
        // 模拟向后端发送回复请求，并将回复添加到对应评论的回复列表中
        const newReplyId = this.comments[commentId - 1].replies.length + 1;
        this.comments[commentId - 1].replies.push({
          id: commentId * 100 + newReplyId,
          content: this.replyContent,
          user: { avatar: 'path_to_avatar', nickname: '半生瓜', time: new Date().toLocaleString() }
        });
        this.replyTo = null;
        this.replyContent = '';
      },
      formatTime(time) {
        // 格式化时间，可以根据需要进行调整
        console.log(time);
        return new Date(time).toLocaleString();
      }
    }
  };
  </script>
  
  <style scoped>
  .comment-list {
    font-family: 'Arial', sans-serif;
  }
  
  .comment-list h2 {
    font-size: 1.8rem;
    color: #333;
    margin-bottom: 20px;
  }
  
  .comments {
    list-style-type: none;
    padding: 0;
  }
  
  .comment-item {
    margin-bottom: 20px;
    
    padding: 15px;
    border-radius: 8px;
    background-color: #f9f9f9;
  }
  
  .comment-item .user-info {
    display: flex;
    align-items: center;
    margin-bottom: 10px;
  }
  
  .comment-item .user-info .avatar1 {
    width: 50px;
    height: 50px;
    border-radius: 50%;
    margin-right: 10px;
  }
  .comment-item .user-info .avatar2 {
    width: 30px;
    height: 30px;
    border-radius: 50%;
    margin-right: 10px;
  }
  
  .comment-item .user-info .username {
    font-weight: bold;
  }
  
  .comment-item .user-info .comment-time {
    margin-left: auto;
    color: #999;
  }
  
  .comment-item .comment-content {
    margin-bottom: 10px;
  }
  
  .comment-item p {
    margin: 0;
    line-height: 1.4;
  }
  
  .comment-item .comment-actions,
  .reply-form .reply-actions {
    margin-top: 10px;
  }
  
  .reply-form {
    margin-top: 10px;
    padding: 10px;
    background-color: #e9ecef;
    border-radius: 8px;
  }
  
  .reply-form textarea {
    width: 100%;
    padding: 8px;
    font-size: 1rem;
    border: 1px solid #ccc;
    border-radius: 4px;
    resize: vertical;
  }
  
  .comment-replies {
    margin-top: 10px;
    padding-left: 20px;
  }
  
  .new-comment-form {
    margin-top: 30px;
  }
  
  .new-comment-form textarea {
    width: 100%;
    padding: 10px;
    font-size: 1rem;
    border: 1px solid #ccc;
    border-radius: 4px;
    resize: vertical;
  }
  
  .new-comment-form .new-comment-actions {
    margin-top: 10px;
    text-align: right;
  }
  
  .new-comment-form .post-comment-button {
    background-color: #007bff;
    color: #fff;
    border: none;
    padding: 8px 16px;
    border-radius: 4px;
    cursor: pointer;
  }
  
  .new-comment-form .post-comment-button:hover {
    background-color: #0056b3;
  }
  </style>