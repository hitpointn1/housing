<script setup>
  import { storeToRefs } from 'pinia';
  import { useBillingStore } from '../../core/stores/billingStore';
  import { getAllEffect } from '../../core/stores/summaryStore';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });
  
  const store = useBillingStore();

  store.getRepairsBill();
  
  const { repairsBill } = storeToRefs(store);

  getAllEffect(() => store.getRepairsBill());

  defineExpose({
    repairsBill: Object
  });
</script>

<template>
  <div class="bill" v-if="repairsBill">
    <i class="fa-solid fa-toolbox"></i>
    <h3>Overhaul</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="repairsBill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: darken(brown, 15%);;
  }
</style>