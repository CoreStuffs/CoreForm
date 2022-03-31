<script setup lang="ts">
    import { ref } from 'vue'
    import UIkit from "uikit";
    import textField from '@/fields/textField/control.vue'
    //UIkit.notification('Hello world.');

    defineProps({
        FormDefinition: { type: [String] },
        FormData: { type: [String] }
    })
    const data = ref("test")
    const schema = ref([{ id: "123", label: "Hello" }])
    const count = ref(10)

</script>

<template>
    <div v-cloak class="cf uk-container">
        <div uk-grid class="uk-grid-small">
            <div class="uk-width-4-5@m uk-form-stacked">

                <h1>{{ msg }}</h1>
                <form class="uk-form-stacked">
                    <fieldset class="uk-fieldset">
                        <textField v-model="data" :schema="schema[0]" />
                        <input v-model="data"/>
                        <hr/>
                        <button type="button" @click="count++">count is: {{ count }}</button>
                    </fieldset>
                </form>
                <div>{{schema}}</div>
                <div>{{data}}</div>
            </div>
        </div>
    </div>

</template>

<style scoped>
</style>
