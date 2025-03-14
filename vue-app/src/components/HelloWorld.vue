<script setup>
import axios from 'axios'
import { ref, onMounted } from 'vue'

const data = ref([])

onMounted(async () => {
  try {
    const response = await axios.get('http://localhost:5032/weatherforecast')
    data.value = response.data
  } catch (error) {
    console.error('Ошибка запроса:', error)
  }
})
</script>

<template>
  <div>
    <h1>Данные с C# API</h1>
    <ul>
      <li v-for="(item, index) in data" :key="index">
        {{ item.date }} - {{ item.temperatureC }}°C
      </li>
    </ul>
  </div>
</template>
