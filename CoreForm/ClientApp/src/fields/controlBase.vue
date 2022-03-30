<script>
    import useVuelidate from '@vuelidate/core'
    export default {
        setup() {
            return { v$: useVuelidate() }
        },
       
        data: function () {
            return {};
        },
        props: {
            schema: {
                type: Object,
                required: true
            },
            width: {
                type: String,
                default: "1-1"
            }
        }
    }
</script>