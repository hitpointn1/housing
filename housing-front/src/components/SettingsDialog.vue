<script setup>
  import { storeToRefs } from 'pinia';
  import { useSettingsStore } from '../core/stores/settingsStore';
  import Dialog from './functional/Dialog.vue';
  import { reportTypes } from '../core/helpers/reportTypes';
  import { useSummaryStore } from '../core/stores/summaryStore';
  import { ref } from 'vue';
  import DropDownList from './functional/DropDownList.vue';

  defineProps({
    showDialog: Boolean
  });

  const summaryStore = useSummaryStore();
  const settingsStore = useSettingsStore();
  const { reportType, reportMonth, reportYear, quarter } = storeToRefs(settingsStore);

  const monthDate = ref(reportYear.value + '-' + reportMonth.value.toString().padStart(2, '0'));
  const quarterRef = ref(quarter.value);
  const quarters = {
    Q1: 1,
    Q2: 2,
    Q3: 3,
    Q4: 4
  }

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
</script>

<template>
  <Dialog :show="showDialog">
    <div class="toolbar__dialog">
      <h3>Settings</h3>

      <div class="toolbar__dialog--field">
        <label>Select report type:</label>
        <DropDownList :options="reportTypes" v-model="reportType" @change="typeChange" />
      </div>
     
      <div v-if="reportType === reportTypes.Monthly" class="toolbar__dialog--field">
        <label>Select month:</label>
        <input type="month" v-model="monthDate" @change="monthChange" />
      </div>

      <template v-else-if="reportType === reportTypes.Quarterly">
        <div class="toolbar__dialog--field">
          <label>Select year:</label>
          <input type="number" min="1990" max="2099" step="1" v-model="reportYear" @change="quarterChange"/>
        </div>
        <div class="toolbar__dialog--field">
          <label>Select quarter:</label>
          <DropDownList :options="quarters" v-model="quarterRef" @change="quarterChange" />
        </div>
      </template>

      <div v-else-if="reportType === reportTypes.Annually" class="toolbar__dialog--field">
        <label>Select year:</label>
        <input type="number" min="1990" max="2099" step="1" v-model="reportYear" @change="yearChange"/>
      </div>

      <div v-if="reportType === reportTypes['All-Time']" class="toolbar__dialog--field">
        <label>Select from:</label>
        <input type="month" v-model="monthDate" @change="monthChange" />
      </div>
    </div>
  </Dialog>
</template>

<style scoped lang="scss">
  .toolbar__dialog {
    display: flex;
    flex-direction: column;
    padding-left: 5px;
    align-items: flex-start;

    &--field {
      margin-top: 15px;
      display: inherit;
      flex-direction: inherit;
      align-items: inherit;
      width: 100%;

      label {
        font-size: 75%;
        margin-bottom: 5px;
      }

      input {
        width: 100%;
      }
    }
  }
</style>