import { defineStore } from 'pinia';
import { appService } from '../appService';
import { useSettingsStore } from './settingsStore';

export const useSummaryStore = defineStore('summaryStore', {
  state: () => ({
    summary: null
  }),
  actions: {
    async getSummary() {
      const store = useSettingsStore();
      this.summary = await appService.getSummary(store.reportDate, store.reportType);
    }
  },
});
