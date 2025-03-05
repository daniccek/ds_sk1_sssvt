<template>
  <nav class="bg-gray-800 p-4 flex justify-between text-white">
    <router-link to="/" class="text-lg font-bold">StockX</router-link>
    <div>
      <router-link to="/cart" class="mx-2">Košík</router-link>
      <router-link v-if="!isLoggedIn" to="/login">Přihlásit</router-link>
      <button v-else @click="logout">Odhlásit</button>
    </div>
  </nav>
</template>

<script setup>
import { computed } from 'vue';

const isLoggedIn = computed(() => !!localStorage.getItem('token'));

const logout = () => {
  localStorage.removeItem('token');
  window.location.reload();
};
</script>
