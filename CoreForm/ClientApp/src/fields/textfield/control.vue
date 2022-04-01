<template>
    <div :schema="schema">
        <label :for="props.schema.id" class="uk-form-label">{{ props.schema.label }}</label>
        <div class="uk-form-controls">
            <input :type="inputType"
                   class="uk-input uk-form-small"
                   v-bind:class="{ 'uk-form-danger': v$.value.$invalid }"
                   :id="props.schema.id"
                   v-model="value" />

            <div class="input-errors" v-for="error of v$.value.$errors" :key="error.$uid">
                <div class="uk-form-danger">{{ error.$message }}</div>
            </div>
        </div>
   
    </div>
</template>
<script language="javascript" setup>
    import { computed, reactive, ref } from 'vue'
    import useVuelidate from '@vuelidate/core'
    import { required, email, minLength } from '@vuelidate/validators'

    const emit = defineEmits(['update:modelValue'])

    const props = defineProps({
        modelValue: String,
        schema: Object
    })

    const rules = {
        value: {
            email: email,
            minLength : minLength(3)
        }
    }


    const value = computed({
        get() {
            return props.modelValue
        },
        set(val) {
            emit('update:modelValue', val)
            v$.value.$touch()
        }
    });

    const v$ = useVuelidate(rules, { value })

    const inputType = computed(() => {
        return "text";
    })

</script>

