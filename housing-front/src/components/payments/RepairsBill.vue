<script setup>
  import PaymentEditableField from '../functional/PaymentEditableField.vue';
  
  defineProps({
      isReadonly: Boolean,
      bill: Object
  })
</script>

<template>
  <div class="bill">
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