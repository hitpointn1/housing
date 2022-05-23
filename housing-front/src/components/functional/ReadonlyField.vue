<script>
  import CurrencySymbol from './CurrencySymbol.vue';
  export default {
    props: {
        value: Number,
        showCurrency: Boolean
    },
    setup(props) {
        const value = props.showCurrency ? Math.abs(props.value ?? 0).toFixed(2) : Math.abs(props.value ?? 0);
        return {
            value
        };
    },
    components: { CurrencySymbol }
  }
</script>

<template>
  <div class="currency">
    <span class="currency__value">{{ value }}</span>
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