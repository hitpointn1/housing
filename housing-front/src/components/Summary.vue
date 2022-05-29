<script setup>
  import { ref } from 'vue';
import { appService } from '../core/appService';
import PaymentField from './functional/PaymentField.vue';

  const summary = ref(null);

  appService.getSummary().then(v => summary.value = v);

  defineExpose({
    summary: Object
  });
</script>

<template>
  <div v-if="summary">
    <h1>Summary</h1>
    <div class="summary__list">
      <PaymentField :title="'Total'" :amount="summary.total" />
      <PaymentField :title="'Total without rent'" :amount="summary.totalWithoutRent" />
      <PaymentField :title="'Rent'" :amount="summary.totalRent" />
    </div>
  </div>
</template>

<style scoped>
  .summary__list {
    display: flex;
    flex-direction: column;
  }
</style>