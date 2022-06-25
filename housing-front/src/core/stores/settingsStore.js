import { defineStore } from 'pinia';
import { reportTypes } from '../helpers/reportTypes';

const now = new Date();

export const useSettingsStore = defineStore('settingsStore', {
  state: () => ({
    reportYear: now.getFullYear(),
    reportMonth: now.getMonth(),
    reportType: 0,
    isReadonly: true
  }),
  actions: {
    setAsReadonly() {
      this.isReadonly = true;
    },
    setAsEditable() {
      if (this.reportType !== reportTypes.Monthly) {
        return;
      }
      
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
    reportDate: (state) => new Date(state.reportYear, state.reportMonth - 1, 1),
    quarter: (state) => Math.floor(state.reportMonth / 4) + 1,
  }
});
