import { defineStore } from 'pinia';

const now = new Date();

export const useSettingsStore = defineStore('settingsStore', {
  state: () => ({
    reportYear: now.getFullYear(),
    reportMonth: now.getMonth() - 1,
    reportType: 0,
    isReadonly: true
  }),
  actions: {
    setAsReadonly() {
      this.isReadonly = true;
    },
    setAsEditable() {
      this.isReadonly = false;
    },
    setMonth(month) {
      this.reportMonth = month;
    },
    setYear(year) {
      this.reportYear = year;
    }
  },
  getters: {
    reportDate: (state) => new Date(state.reportYear, state.reportMonth, 1),
  }
});
