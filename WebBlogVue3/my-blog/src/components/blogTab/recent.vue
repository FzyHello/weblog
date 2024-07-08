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
        <div class="markdown-body" v-html="md.render(selectedItem.content)" ></div>
        <comment :comment="comment" />
      </div>
      <div class="table-of-contents">
          <div class="toc-title">本文目录</div>
          <!-- 遍历标题数组，每个标题独占一行 -->
            <p v-for="(heading, index) in selectedItem.headings" :key="index">
              <a :href="'#heading-' + index" class="custom-link">{{ heading }}</a>
            </p>
          <hr>
          <p style="font-size: 15px;" ><Location style="  width: 18px; /* 调整图标的宽度 */height: 14px; /* 调整图标的高度 */" /> 回到顶部</p>
          <p style="font-size: 15px;" ><ChatDotRound style="  width: 18px; /* 调整图标的宽度 */height: 12px; /* 调整图标的高度 */" />  参与讨论</p>
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
import { Search, Edit, Share, Delete, Service,Location,ChatDotRound } from "@element-plus/icons-vue";
import { reactive } from "vue";
import { Post } from "@/service/baseService.ts";
import MarkdownIt from "markdown-it";
import markdownItToc from "markdown-it-table-of-contents";
import comment from "@/components/blogTab/comment.vue"
//import TableOfContents from "@/components/blogTab/tableOfContents.vue";
const md = new MarkdownIt()
md.use(markdownItToc, {
  includeLevel: [1, 2, 3], // 指定哪些标题级别需要包含在目录中
  containerClass: 'table-of-contents' // 可选：自定义目录容器的 class
});

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
  // Parse content to generate table of contents
  const tokens = md.parse(selectedItem.content);

    // Extract headings
    const headings = [];
  for (let i = 0; i < tokens.length; i++) {
    const token = tokens[i];
    if (token.type === 'heading_open' && tokens[i + 1] && tokens[i + 1].type === 'inline') {
      const headingText = tokens[i + 1].content;
      headings.push(headingText);
    }
  }

  // Update selectedItem with headings
  selectedItem.headings = headings;
  console.log(selectedItem.headings);
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
      height: 150px;

      &-info {
        display: flex;
        flex-direction: column;
      }

      &-title {
        font-size: 24px;
        margin-top: 20px;
        font-weight: bold;
        margin-bottom: 5px;
      }

      &-details {
        font-size: 14px;
        margin-top: 25px;
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
<style lang="scss">
@import 'github-markdown-css';

/*//自己也可以再调整调整 (贡献一版 我们调整的一版样式)*/
.markdown-body {
  padding: 20px;
  border-radius: 10px;
  min-width: 200px;
  max-width: 900px;
  font-size: 15px;
  h2 {
    font-size: 25px;
    margin: 1em 0 15px;
    padding-top: 0.8em;
    padding-bottom: 0.8em;
  }
  h3 {
    font-size: 20px;
    margin: 22px 0 16px;
  }
  h4 {
    font-size: 1px;
    margin: 20px 0 16px;
  }
  h5 {
    font-size: 12px;
    margin: 16px 0 16px;
    font-weight: 700;
  }
  p {
    font-size: 14px;
    line-height: 24px;
    color: #666666;
    margin-top: 0px;
    margin: 8px 0;
    margin: 14px 0 14px;
  }
  pre {
    background-color: #eee;
    margin-bottom: 8px;
    margin-top: 8px;
    margin: 12px 0 12px;
  }
  blockquote {
    margin-bottom: 8px;
    margin-top: 8px;
    margin: 14px 0 14px;
    background-color: #eee;
    padding: 16px 16px;
  }
  tr {
    background-color: #f5f5f5;
  }
  code {
    background-color: #eee;
  }
  ul,
  ol,
  li {
    list-style: unset;
    font-size: 14px;
    line-height: 20px;
    color: #666666;
    margin-top: 0px;
    margin: 8px 0;
  }
  blockquote {
    border-color: #48b6e2;
  }
  table {
    display: table;
    width: 100%;
    max-width: 100%;
    margin-bottom: 20px;
  }
}

</style>
<style scoped>
.content-wrapper {
  display: flex;
  align-items: flex-start; /* 顶部对齐 */
}

.blogs-detail-box {
  flex: 1; /* 自动填充剩余空间 */
  margin-right: 20px; /* 可根据需要调整右侧间距 */
}

.table-of-contents {
  position: fixed; /* 或者 absolute，根据需求选择 */
  top: 50px; /* 调整距离顶部的位置 */
  right: 10ch; /* 调整距离右侧的位置 */
  width: 200px; /* 调整目录宽度 */
  padding: 20px;
  border-radius: 5px;
  z-index: 1000; /* 确保目录在其他内容上方显示 */
}

.toc-title {
  font-size: 1rem;
  font-weight: bold;
  margin-bottom: 10px;
  color: #333;
}






.custom-link {
  text-decoration: none; /* 去掉下划线 */
  color: #488eda; /* 设置为浅蓝色 */
  right: inherit;
  margin-left: 0px;
  font-size: 15px;;
}
</style>