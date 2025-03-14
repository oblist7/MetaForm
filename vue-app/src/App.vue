<template>
  <FormComponent msg="Welcome to Your Vue.js App"/>
  <SubmissionsList msg="Welcome to Your Vue.js App"/>
</template>

<script>
import FormComponent from './components/FormComponent.vue'
import SubmissionsList from './components/SubmissionsList.vue'

export default {
  name: 'App',
  components: {
    FormComponent,
    SubmissionsList
  }
}
</script>

<style>
#app {
  font-family: Avenir, Helvetica, Arial, sans-serif;
  -webkit-font-smoothing: antialiased;
  -moz-osx-font-smoothing: grayscale;
  text-align: center;
  color: #2c3e50;
  margin-top: 60px;
}
</style>
