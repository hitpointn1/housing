<script setup>
  import { ref } from 'vue';
  import Payments from './components/Payments.vue';
  import Summary from './components/Summary.vue';
  import Toolbar from './components/Toolbar.vue';
  
  const summary = {
    total: {
      value: 16740.00,
      diff: 250.00
    },
    rent: {
      value: 13000.00,
      diff: 0.0
    },
    paymentsOnly: {
      value: 3470.00,
      diff: -250.0
    }
  };

  const isReadonly = ref(false);

  const save = () => {
    isReadonly.value = true;
  };

  const edit = () => {
    isReadonly.value = false;
  };
</script>

<template>
  <div>
    <Toolbar :isReadonly="isReadonly" @save="save" @edit="edit" />
    <Summary :summary="summary" />
    <Payments :isReadonly="isReadonly" />
  </div>
</template>

<style lang="scss">
  #app {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    font-size: 40px;
    text-align: center;
    color: #2c3e50;
  }

  input {
    font-family: Avenir, Helvetica, Arial, sans-serif;
    -webkit-font-smoothing: antialiased;
    -moz-osx-font-smoothing: grayscale;
    font-size: 40px;
    color: #212529;
    background-color: #fff;
    background-clip: padding-box;
    border: none;
    outline: none;
    max-width: 300px;
    padding: 0;
  }
</style>
