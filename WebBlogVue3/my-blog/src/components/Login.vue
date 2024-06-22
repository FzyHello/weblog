<template>
  <div class="login-container">
    <h2>Login</h2>
    <form @submit.prevent="handleSubmit">
      <div class="form-group">
        <label for="username">Username</label>
        <input type="text" id="username" v-model="username" required />
      </div>
      <div class="form-group">
        <label for="password">Password</label>
        <input type="password" id="password" v-model="password" required />
      </div>
      <button type="submit">Login</button>
    </form>
    <p v-if="loginError" class="error-message">{{ loginError }}</p>
  </div>
</template>
  
  <script>
import { ref } from "vue";
import axios from "axios";

export default {
  name: "LoginPage",
  setup() {
    const username = ref("");
    const password = ref("");
    const loginError = ref("");

    const loginData = {
      userName: "admin",
      password: "123456",
    };

    async function handleSubmit() {
      try {
        // 发起请求qq
        const response = await axios.post(
          "http://localhost:5214/Login",loginData
        ); // 替换为你的后端接口地址

        // 处理响应
        console.log(response.data); // 这里假设后端返回的数据是一个 JSON 对象

        // 可以在这里进行进一步的处理，比如根据响应来更新页面状态或者跳转到下一个页面等
      } catch (error) {
        // 处理错误
        console.error("Error fetching data: ", error);
        // 可以根据错误情况做出相应的处理，比如显示错误信息给用户q
      }
    }

    return {
      username,
      password,
      loginError,
      handleSubmit,
    };
  },
};
</script>
  
  <style scoped>
.login-container {
  max-width: 400px;
  margin: 0 auto;
  padding: 20px;
  border: 1px solid #ccc;
  border-radius: 5px;
  background-color: #f9f9f9;
}

h2 {
  text-align: center;
}

.form-group {
  margin-bottom: 10px;
}

label {
  display: block;
  margin-bottom: 5px;
}

input[type="text"],
input[type="password"] {
  width: 100%;
  padding: 8px;
  font-size: 16px;
  border: 1px solid #ccc;
  border-radius: 4px;
}

button {
  width: 100%;
  padding: 10px;
  font-size: 18px;
  background-color: #4caf50;
  color: white;
  border: none;
  border-radius: 4px;
  cursor: pointer;
}

button:hover {
  background-color: #45a049;
}

.error-message {
  color: red;
  text-align: center;
  margin-top: 10px;
}
</style>