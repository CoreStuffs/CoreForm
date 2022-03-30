<template>
    <div :schema="schema">
        <label :for="schema.id" class="uk-form-label">{{ schema.label }}<div class="required-tag" v-if="$isrequired"></div></label>
        <div class="uk-form-controls">
            <input
                   :type="inputType"
                   :placeholder="schema.placeholder"
                   class="uk-input uk-form-small"
                   v-bind:class="{ 'uk-form-danger': $error }"
                   :id="schema.id"
                   v-model="data"
                   @input="updateInput" />{{inputType}}
        </div>
        <span v-if="$errorMessage" class="error-message">{{ $errorMessage }}</span>
    </div>
</template>
<script>
    import controlBase from "@/fields/controlBase.vue";
    export default {
        extends: controlBase,
        data() {
            return { data: this.value };
        },
        computed: {
            inputType: function () {
                return "text";
            },
        },
        methods: {
            updateInput: function () {
                this.$emit("input", this.$el.getElementsByTagName("input")[0].value);
                if (this.$validation) this.$validation.$touch();
            },
        },
        watch: {
            value: function (newValue) {
                this.data = newValue;
            },
        },
        props: {
            value: {
                type: String,
                required: false,
            },
        },
    };
</script>

