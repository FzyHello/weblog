import { createRouter, createWebHashHistory } from 'vue-router';

const routes = [
 {
    path: '/',
    redirect: '/login',
  },
  {
    path: '/login',
    component: () => import('@/components/Login.vue'),
    key: 'login'
  },
];

const router = createRouter({
  history: createWebHashHistory(),
  routes,
});

export default router;