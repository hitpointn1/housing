<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });
  
  const bill = ref(null);
  appService.getRepairsBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-toolbox"></i>
    <h3>Overhaul</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Invoice amount'"
      :data="bill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: darken(brown, 15%);;
  }
</style>