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

  store.getAdditionalBill();

  getAllEffect(() => store.getAdditionalBill());

  const { additionalsBill } = storeToRefs(store);

  defineExpose({
    additionalsBill: Object
  });
</script>

<template>
  <div class="bill" v-if="additionalsBill">
    <i class="fa-solid fa-warehouse"></i>
    <h3>Elevator, guards, internet, ... etc</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="additionalsBill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'internet'"
      :data="additionalsBill.internet"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: goldenrod;
  }
</style>