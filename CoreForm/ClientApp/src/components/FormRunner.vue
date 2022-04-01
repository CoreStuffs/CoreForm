<script setup lang="ts">
    import { ref } from 'vue'
    import UIkit from "uikit";
    import axios from "axios";
    import textField from '@/fields/textField/control.vue'
    //UIkit.notification('Hello world.');

    defineProps({
        FormDefinition: { type: [String] },
        FormData: { type: [String] }
    })
    const data = ref({id:124578, value : ""})
    const schema = ref([{ id: "123", label: "Hello" }])

    fetch("https://restcountries.com/v2/regionalbloc/eu")
        .then(response => response.json())
        .then(data => (alert(JSON.stringify(data))))

</script>

<template>
    <div v-cloak class="cf uk-container">
        <div uk-grid class="uk-grid-small">
            <div class="uk-width-4-5@m uk-form-stacked">

                <h1>{{ msg }}</h1>
                <form class="uk-form-stacked">
                    <fieldset class="uk-fieldset">
                        <textField v-model="data.value" :schema="schema[0]" />
                        <input v-model="data.value"/>
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
