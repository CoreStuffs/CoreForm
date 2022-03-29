<script setup lang="ts">
    import { ref } from 'vue'
    import UIkit from "uikit";
    UIkit.notification('Hello world.');

    defineProps({
        FormDefinition: { type: [String] },
        FormData: { type: [String] }
    })

const count = ref(10)
</script>

<template>
    <div v-cloak class="cf uk-container">
        <div uk-grid class="uk-grid-small">
            <div class="uk-width-4-5@m uk-form-stacked">

                <h1>{{ msg }}</h1>

                <button type="button" @click="count++">count is: {{ count }}</button>
                </div>
            </div>
        </div>

</template>

<style scoped>

</style>
