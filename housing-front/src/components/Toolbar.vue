<script setup>
  import { storeToRefs } from 'pinia';
  import { ref } from 'vue';
  import { useSettingsStore } from '../core/stores/settingsStore';
  import SettingsDialog from './SettingsDialog.vue';

  defineProps({
    isReadonly: Boolean
  });

  const store = useSettingsStore();
  const { isReadonly, reportDate } = storeToRefs(store);

  const showDialog = ref(false);

  const toggleDialog = () => {
    showDialog.value = !showDialog.value;
  };

  const readonly = () => {
    store.setAsReadonly();
  };
  
  const editable = () => {
    store.setAsEditable();
  };
  
  defineExpose({
    showDialog: Boolean,
    reportDate: Date,
    toggleDialog: Function,
    readonly: Function,
    editable: Function
  });
</script>

<template>
  <div class="toolbar">
    <span class="toolbar__date">{{ reportDate.toString() }}</span>
    <i class="fa-solid fa-cog" @click="toggleDialog"></i>
    <i class="fa-solid fa-file-excel"></i>
    <i v-if="isReadonly" class="fa-solid fa-pen-to-square" @click="editable"></i>
    <i v-else class="fa-solid fa-floppy-disk" @click="readonly"></i>
  </div>
  <SettingsDialog :showDialog="showDialog" @onClose="toggleDialog" ref="dialog"></SettingsDialog>
</template>

<style scoped lang="scss">
  .toolbar {
    display: flex;
    justify-content: flex-end;
    
    .fa-file-excel {
      color: $green-color;
    }

    .fa-cog {
      color: $blue-color;
    }

    i {
      margin-left: 10px;
    }

    i:hover {
      cursor: pointer;
    }
  }
</style>