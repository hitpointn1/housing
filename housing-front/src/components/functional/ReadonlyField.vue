<script setup>
  import { computed } from '@vue/reactivity';
  import CurrencySymbol from './CurrencySymbol.vue';

  const props = defineProps({
    value: Number,
    showCurrency: Boolean
  });

  const valueRef = computed(() => props.showCurrency ? Math.abs(props.value ?? 0).toFixed(2) : Math.abs(props.value ?? 0).toString());
</script>

<template>
  <div class="currency">
    <span class="currency__value">{{ valueRef }}</span>
    <CurrencySymbol v-if="showCurrency" />
  </div>
</template>

<style scoped lang="scss">
  .currency {
    display: flex;
  }

  .currency__value {
    margin-left: 5px;
  }
</style>