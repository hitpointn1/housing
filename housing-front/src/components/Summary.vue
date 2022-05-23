<script setup>
  import PaymentField from './functional/PaymentField.vue';

  defineProps({
    summary: Object
  });

</script>

<template>
  <h1>Summary</h1>
  <div class="summary">
    <PaymentField :title="'Total'" :amount="summary.total" />
    <PaymentField :title="'Total without rent'" :amount="summary.paymentsOnly" />
    <PaymentField :title="'Rent'" :amount="summary.rent" />
  </div>
</template>

<style scoped>
  .summary {
    display: flex;
    flex-direction: column;
  }
</style>