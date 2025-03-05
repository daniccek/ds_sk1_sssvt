<template>
  <div class="login-container">
    <h2>Přihlášení</h2>
    <form @submit.prevent="handleLogin">
      <input v-model="email" type="email" placeholder="E-mail" required />
      <input v-model="password" type="password" placeholder="Heslo" required />
      <button type="submit">Přihlásit</button>
    </form>
    <p v-if="errorMessage">{{ errorMessage }}</p>
  </div>
</template>

<script setup lang="ts">
import { ref } from "vue";
import { loginUser } from "@/services/authService";

const email = ref("");
const password = ref("");
const errorMessage = ref("");

const handleLogin = async () => {
  try {
    const response = await loginUser(email.value, password.value);
    console.log("Přihlášení úspěšné:", response);
  } catch (error) {
    errorMessage.value = "Chyba při přihlášení";
  }
};
</script>

<style scoped>
.login-container {
  max-width: 400px;
  margin: auto;
  text-align: center;
}
</style>
