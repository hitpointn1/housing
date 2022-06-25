<script setup>
  import { storeToRefs } from 'pinia';
  import { useBillingStore } from '../../core/stores/billingStore';
  import { getAllEffect } from '../../core/stores/summaryStore';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  });

  const store = useBillingStore();

  store.getElecticityBill();
  
  const { electricityBill } = storeToRefs(store);

  getAllEffect(() => store.getElecticityBill());
</script>

<template>
  <div class="bill" v-if="electricityBill">
    <i class="fa-solid fa-plug-circle-bolt"></i>
    <h3>Electricity</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="electricityBill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Consumption readings'"
      :data="electricityBill.consumptionReadings" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: cyan;
  }
</style>