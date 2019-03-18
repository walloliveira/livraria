<template lang="pug">
  .container.is-fluid
    .box
      livro-list
</template>
<script>
import LivroList from 'App/LivroList.vue';

export default {
  components: {
    LivroList,
  },
};
</script>
