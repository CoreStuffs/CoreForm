<script setup language="javascript">
    import { ref, markRaw, defineAsyncComponent, watch  } from 'vue'
    import UIkit from "uikit";
    
    //import textfield from '@/fields/textfield/control.vue'

    //defineProps({
    //    FormDefinition: { type: [String] },
    //    FormData: { type: object }
    //})


    const components = {
        "textfield": defineAsyncComponent(() => import('@/fields/textfield/control.vue'))
    }

    const loadForm = (d) => {
        schema.value = d.formDefinition;
        model.value = d.formDataModel;
        data.value = d.formInstanceData;
        UIkit.notification('Form load completed');
    }

    fetch("/api/forminstance/10B4415E-BF75-4993-AC64-EE17D7E8791C")
        .then(response => response.json())
        .then(d => {
            loadForm(d)
        })

    const getComp = (name) => {
        return markRaw(components[name])
    }



    const model = ref({})
    const schema = ref({})
    const data = ref({})




</script>

<template>
    <div v-cloak class="cf uk-container">
        <div uk-grid class="uk-grid-small">
            <div class="uk-width-4-5@m uk-form-stacked">

                <h1>{{ msg }}</h1>
                <form class="uk-form-stacked">
                    <fieldset class="uk-fieldset">
                        <div>
                            <component v-for="comp in schema.components" :key="comp.id" :is="getComp(comp.type)" v-model="data.values[comp.dataProperty]" :schema="comp" />
                        </div>
                    </fieldset>
                </form>
                <div>{{schema}}</div>
                <div>{{model}}</div>
                <div>{{data}}</div>
            </div>
        </div>
    </div>

</template>

<style scoped>
</style>
