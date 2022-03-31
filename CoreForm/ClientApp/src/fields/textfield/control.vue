<template>
    <div :schema="schema">
        <label :for="props.schema.id" class="uk-form-label">{{ props.schema.label }}</label>
        <div class="uk-form-controls">
            <input :type="inputType"
                   class="uk-input uk-form-small"
                   v-bind:class="{ 'uk-form-danger': v$.myValue.$invalid }"
                   :id="props.schema.id"
                   :value="props.modelValue" @input="onInput" />{{inputType}}
        </div>
        {{v$.myValue.$error}}
    </div>
</template>
<script language="javascript" setup>
    import { computed, reactive, ref } from 'vue'
    import useVuelidate from '@vuelidate/core'
    import { required, email } from '@vuelidate/validators'

    const props = defineProps({
        modelValue: String,
        schema: Object
    })

    const formState = reactive({
        myValue: props.modelValue,
    })

    const rules = {
        myValue: {
            required
        }
    }

    const v$ = useVuelidate(rules, formState)


    const emit = defineEmits(['update:modelValue'])

    const inputType = computed(() => {
        return "text";
    })

    const onInput = (event) => {

        emit('update:modelValue', event.target.value);
    }



</script>

