<template>
  <div class="p-6">
    <h1 class="text-2xl font-bold">StockX - Produkty</h1>
    <div v-if="loading">Načítám produkty...</div>
    <div v-else class="grid grid-cols-3 gap-4">
      <div v-for="product in products" :key="product.id" class="border p-4">
        <img :src="product.imageUrl" class="w-32 h-32 object-cover" />
        <h2 class="text-lg">{{ product.name }}</h2>
        <p class="text-sm">{{ product.price }} Kč</p>
        <router-link :to="`/product/${product.id}`">Více</router-link>
      </div>
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api';

const products = ref([]);
const loading = ref(true);

onMounted(async () => {
  try {
    const response = await api.get('/products');
    products.value = response.data;
  } catch (error) {
    console.error('Chyba při načítání produktů:', error);
  } finally {
    loading.value = false;
  }
});
</script>
