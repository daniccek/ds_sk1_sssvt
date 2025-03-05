<template>
  <div class="p-6">
    <h1 class="text-3xl font-bold">{{ product.name }}</h1>
    <p>{{ product.description }}</p>
    <img :src="product.imageUrl" class="w-64" />
    <p class="text-xl font-semibold">{{ product.price }} Kč</p>
    <button class="bg-blue-500 text-white p-2">Koupit</button>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import { useRoute } from 'vue-router';
import api from '../api';

const route = useRoute();
const product = ref(null);

onMounted(async () => {
  const response = await api.get(`/products/${route.params.id}`);
  product.value = response.data;
});
</script>
