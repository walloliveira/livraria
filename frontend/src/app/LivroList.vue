<template lang="pug">
  .container.is-fluid
    .is-12
      a(@click="openForm()").button.is-large.is-primary Adicionar
    .is-12
      b-table(:data="data")
        template(slot-scope="props")
          b-table-column(field="nome" label="Nome")
            | {{ props.row.nome }}
          b-table-column(field="autor" label="Autor")
            | {{ props.row.autor }}
          b-table-column(field="paginas" label="Total de Páginas" right)
            | {{ props.row.paginas }}
          b-table-column(label="Ações" centered)
            button.button.is-warning(@click="openForm(props.row)") Editar
            button.button.is-danger(@click="deletar(props.row)") Deletar
        template(slot="empty")
          .content.has-text-grey.has-text-centered
            p
              b-icon(icon='emoticon-sad'   size='is-large')
            p Nenhum livro adicionado.

</template>

<script>
import {
  findAll,
  remove,
  update,
  save,
} from 'Domain/LivroService';
import LivroAdd from 'App/LivroAdd.vue';

export default {
  name: 'LivroList',
  data() {
    return {
      data: [],
    };
  },
  methods: {
    openForm(livro = undefined) {
      this.$modal.open({
        parent: this,
        component: LivroAdd,
        hasModalCard: true,
        props: {
          livro,
        },
        events: {
          submitted: value => this.save(value),
        },
      });
    },
    save(livro) {
      if (livro.id) {
        this.put(livro.id, {
          nome: livro.nome,
          autor: livro.autor,
          paginas: livro.paginas,
        });
        return;
      }
      save(livro)
        .then(() => {
          this.openMessage('Livro adicionado com sucesso!');
          this.getAll();
        });
    },
    put(id, livro) {
      update(id, livro)
        .then(() => {
          this.openMessage('Livro atualizado com sucesso!');
          this.getAll();
        });
    },
    deletar(livro) {
      remove(livro)
        .then(() => {
          this.openMessage('Livro removido com sucesso!');
          this.getAll();
        });
    },
    openMessage(message) {
      this.$toast.open({
        message,
        type: 'is-success',
      });
    },
    getAll() {
      findAll()
        .then(({ data }) => {
          this.data = data;
        });
    },
  },
  created() {
    this.getAll();
  },
};
</script>
