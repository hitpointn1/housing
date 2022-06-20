import { defineStore } from 'pinia';

const now = new Date();

export const useSettingsStore = defineStore('settingsStore', {
  state: () => ({
    reportDate: new Date(now.getFullYear(), now.getMonth() - 1, 1),
    reportType: 0,
    isReadonly: true
  }),
  actions: {
    readonly() {
      this.isReadonly = true;
    },
    editable() {
      this.isReadonly = false;
    }
  }
});
