<template>
  <div class="container mt-5">
    <div class="row">
      <div class="col-12 col-md-6">
        <FormComponent />
      </div>
      <div class="col-12 col-md-6">
        <SubmissionsList />
      </div>
    </div>
  </div>
</template>

<script>
import FormComponent from './components/FormComponent.vue'
import SubmissionsList from './components/SubmissionsList.vue'

export default {
  components: { FormComponent, SubmissionsList }
}
</script>
