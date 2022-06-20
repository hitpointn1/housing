<script setup>
  import PaymentField from './functional/PaymentField.vue';
  import { useSummaryStore } from '../core/stores/summaryStore';
  import { storeToRefs } from 'pinia';

  const store = useSummaryStore();

  store.getSummary();
  
  const { summary } = storeToRefs(store);

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