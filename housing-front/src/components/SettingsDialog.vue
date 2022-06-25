<script setup>
  import { storeToRefs } from 'pinia';
  import { useSettingsStore } from '../core/stores/settingsStore';
  import Dialog from './functional/Dialog.vue';
  import { reportTypes } from '../core/helpers/reportTypes';
  import { useSummaryStore } from '../core/stores/summaryStore';
  import { ref } from 'vue';

  defineProps({
    showDialog: Boolean
  });

  const summaryStore = useSummaryStore();
  const settingsStore = useSettingsStore();
  const { reportType, reportMonth, reportYear, quarter } = storeToRefs(settingsStore);

  const monthDate = ref(reportYear.value + '-' + reportMonth.value.toString().padStart(2, '0'));
  const quarterRef = ref(quarter.value);

  const typeChange = () => {
    summaryStore.getAll();
  }

  const monthChange = () => {
    const parts = monthDate.value.split('-', 2);
    const yearValue = parseInt(parts[0]);
    const monthValue = parseInt(parts[1]);
    settingsStore.setYear(yearValue);
    setMonthAndReload(monthValue);
  }

  const quarterChange = () => {
    setMonthAndReload(quarterRef.value * 3 - 2);
  }

  const yearChange = () => {
    setMonthAndReload(1);
  }

  const setMonthAndReload = (month) => {
    settingsStore.setMonth(month);
    summaryStore.getAll();
  }

  defineExpose({
    reportType: Number,
    reportTypes: Object,
    monthDate: String,
    reportYear: Number,
    quarterRef: Number
  });
</script>

<template>
  <Dialog :show="showDialog">
    <div class="toolbar__dialog">
      <h3>Settings</h3>
      <label>Select report type:</label>
      <select v-model="reportType" @change="typeChange">
        <option v-for="report in Object.keys(reportTypes)" :value="reportTypes[report]">{{ report }}</option>
      </select>
      <template v-if="reportType === reportTypes.Monthly">
        <label>Select month:</label>
        <input type="month" v-model="monthDate" @change="monthChange" />
      </template>
      <template v-else-if="reportType === reportTypes.Quarterly">
        <label>Select year:</label>
        <input type="number" min="1990" max="2099" step="1" v-model="reportYear" @change="quarterChange"/>
        <label>Select quarter:</label>
        <select v-model="quarterRef" @change="quarterChange">
          <option :value="1">Q1</option>
          <option :value="2">Q2</option>
          <option :value="3">Q3</option>
          <option :value="4">Q4</option>
        </select>
      </template>
      <template v-else-if="reportType === reportTypes.Annually">
        <label>Select year:</label>
        <input type="number" min="1990" max="2099" step="1" v-model="reportYear" @change="yearChange"/>
      </template>
    </div>
  </Dialog>
</template>

<style scoped lang="scss">
  .toolbar__dialog {
    display: flex;
    flex-direction: column;
  }
</style>