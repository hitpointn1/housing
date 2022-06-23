<script setup>
  import PaymentField from './functional/PaymentField.vue';
  import { useSummaryStore } from '../core/stores/summaryStore';
  import { storeToRefs } from 'pinia';
  import { useSettingsStore } from '../core/stores/settingsStore';
  import { reportValues } from '../core/helpers/reportTypes';

  const store = useSummaryStore();

  store.getSummary();
  
  const { summary } = storeToRefs(store);
  const { reportType } = storeToRefs(useSettingsStore());

  defineExpose({
    summary: Object,
    reportValues: Object,
    reportType: Number
  });
</script>

<template>
  <div v-if="summary">
    <h1>{{ reportValues[reportType] }} Summary</h1>
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