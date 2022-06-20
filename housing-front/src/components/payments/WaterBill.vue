<script setup>
  import { storeToRefs } from 'pinia';
  import { useBillingStore } from '../../core/stores/billingStore';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });

  const store = useBillingStore();

  store.getWaterBill();
  
  const { waterBill } = storeToRefs(store);

  defineExpose({
    waterBill: Object
  });
</script>

<template>
  <div class="bill" v-if="waterBill">
    <i class="fa-solid fa-droplet"></i>
    <h3>Water</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="waterBill.payment"
      :isCurrency="true" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Hot water readings'"
      :data="waterBill.hotReadings" />

    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Cold water readings'"
      :data="waterBill.coldReadings" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: $blue-color;
  }
</style>