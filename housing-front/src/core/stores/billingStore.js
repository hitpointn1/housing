import { defineStore } from 'pinia';
import { appService } from '../appService';
import { useSettingsStore } from './settingsStore';

export const useBillingStore = defineStore('billingStore', {
  state: () => ({
    waterBill: null,
    rentBill: null,
    repairsBill: null,
    heatingBill: null,
    electricityBill: null,
    additionalsBill: null
  }),
  actions: {
    async getWaterBill() {
      const store = useSettingsStore();
      this.waterBill = await appService.getWaterBill(store.reportDate, store.reportType);
    },
    async getRentBill() {
      const store = useSettingsStore();
      this.rentBill = await appService.getRentBill(store.reportDate, store.reportType);
    },
    async getRepairsBill() {
      const store = useSettingsStore();
      this.repairsBill = await appService.getRepairsBill(store.reportDate, store.reportType);
    },
    async getHeatingBill() {
      const store = useSettingsStore();
      this.heatingBill = await appService.getHeatingBill(store.reportDate, store.reportType);
    },
    async getElecticityBill() {
      const store = useSettingsStore();
      this.electricityBill = await appService.getElecticityBill(store.reportDate, store.reportType);
    },
    async getAdditionalBill() {
      const store = useSettingsStore();
      this.additionalsBill = await appService.getAdditionalBill(store.reportDate, store.reportType);
    }
  }
});
