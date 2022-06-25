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

  store.getHeatingBill();
  
  const { heatingBill } = storeToRefs(store);

  getAllEffect(() => store.getHeatingBill());
</script>

<template>
  <div class="bill" v-if="heatingBill">
    <i class="fa-solid fa-temperature-arrow-up"></i>
    <h3>Heating</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="heatingBill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: $red-color;
  }
</style>