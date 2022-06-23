import { defineStore } from 'pinia';
import { appService } from '../appService';
import { useSettingsStore } from './settingsStore';

export const getAllEffect = (action) => {
  useSummaryStore().$onAction(({ name, after }) => {
    if (name === 'getAll') {
      after(() => {
        action();
      });
    }
  })
};

export const useSummaryStore = defineStore('summaryStore', {
  state: () => ({
    summary: null
  }),
  actions: {
    async getSummary() {
      const store = useSettingsStore();
      this.summary = await appService.getSummary(store.reportDate, store.reportType);
    },
    getAll() {
      return this.getSummary();
    }
  },
});
