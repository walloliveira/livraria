<template lang="pug">
  .modal-card
    header.modal-card-head
      p.modal-card-title {{ title }}
    .modal-card-body
      b-field(
        label="Nome"
      )
        b-input(
          type="text"
          v-model="payload.nome"
          maxlength="100"
        )
      b-field(
        label="Autor"
      )
        b-input(
          type="text"
          v-model="payload.autor"
          maxlength="50"
        )
      b-field(
        label="Total de Páginas"
      )
        b-input(
          type="number"
          v-model="payload.paginas"
        )
    .modal-card-foot
      button.button(type="button" @click="$parent.close()") Fechar
      button.button.is-primary(@click="salvar()") Salvar
</template>

<script>

export default {
  props: {
    livro: {
      type: Object,
    },
  },
  data() {
    return {
      payload: {},
    };
  },
  computed: {
    title() {
      return this.hasLivro() ? 'Editando Livro' : 'Novo Livro';
    },
  },
  methods: {
    salvar() {
      this.$emit('submitted', this.payload);
      this.$parent.close();
    },
    hasLivro() {
      return this.livro !== undefined;
    },
  },
  created() {
    if (this.hasLivro()) {
      this.payload = {
        ...this.livro,
      };
    }
  },
};
</script>
