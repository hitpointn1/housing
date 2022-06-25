<script setup>
  import { storeToRefs } from 'pinia';
  import Payments from './components/Payments.vue';
  import Summary from './components/Summary.vue';
  import Toolbar from './components/Toolbar.vue';
  import { useSettingsStore } from './core/stores/settingsStore';

  const store = useSettingsStore();

  const { isReadonly } = storeToRefs(store);
</script>

<template>
  <div>
    <Toolbar :isReadonly="isReadonly" />
    <Summary />
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
