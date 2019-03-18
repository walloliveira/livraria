<template lang="pug">
  .app
    .image
    router-view
</template>

<style lang="scss">
  @import "~bulma/bulma";
</style>

<style lang="sass" scoped>
  .image
    background-image: url('/home.jpg')
    position: fixed
    height: 100%
    width: 100%
</style>
