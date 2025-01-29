<template>
  <div class="p-6">
    <FilterSidebar @filter="applyFilter" />
    <div class="grid grid-cols-3 gap-4">
      <ProductCard v-for="product in filteredProducts" :key="product.id" :product="product" />
    </div>
  </div>
</template>

<script setup>
import { ref, onMounted } from 'vue';
import api from '../api';
import ProductCard from '../components/ProductCard.vue';
import FilterSidebar from '../components/FilterSidebar.vue';

const products = ref([]);
const filteredProducts = ref([]);

onMounted(async () => {
  const response = await api.get('/products');
  products.value = response.data;
  filteredProducts.value = response.data;
});

const applyFilter = (filter) => {
  filteredProducts.value = products.value.filter(p => p.brand === filter);
};
</script>