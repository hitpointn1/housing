<script setup>
  import { ref } from 'vue';
  import { appService } from '../../core/appService';
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean
  });
  
  const bill = ref(null);
  appService.getRentBill().then(v => bill.value = v);

  defineExpose({
    bill: Object
  });
</script>

<template>
  <div class="bill" v-if="bill">
    <i class="fa-solid fa-building-user"></i>
    <h3>Rent</h3>
    <PaymentEditableField
      :isReadonly="isReadonly"
      :title="'Rent amount'"
      :data="bill.payment"
      :isCurrency="true" />
    
  </div>
</template>

<style scoped lang="scss">
  i {
    align-self: baseline;
    color: purple;
  }
</style>