<script setup>
  import { storeToRefs } from 'pinia';
  import { useBillingStore } from '../../core/stores/billingStore';
  import { getAllEffect } from '../../core/stores/summaryStore';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });
  
  const store = useBillingStore();

  store.getRentBill();
  
  const { rentBill } = storeToRefs(store);

  getAllEffect(() => store.getRentBill());

  defineExpose({
    rentBill: Object
  });
</script>

<template>
  <div class="bill" v-if="rentBill">
    <i class="fa-solid fa-building-user"></i>
    <h3>Rent</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Rent amount'"
      :data="rentBill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: purple;
  }
</style>