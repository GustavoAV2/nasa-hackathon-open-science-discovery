<template>
  <div
    class="card border border-gray-700 bg-gray-700 text-gray-50 transition-shadow shadow-xl hover:shadow-xl"
  >
    <div
      class="flex flex-col items-center p-1 md:p-4 max-w-xs md:w-96 max-h-48"
    >
      <span class="text-md text-gray-50 font-semibold">
        {{ name }}
      </span>
      <hr class="border-gray-100" />
      <p class="text-sm text-gray-200" v-html="description_formatted"></p>

      <div class="flex">
        <button
          v-on:click="toProject()"
          class="flex items-center justify-center max-h-max focus:outline-none focus:ring focus:border-blue-300 rounded max-w-max text-gray-100 bg-green-500 hover:bg-green-600 px-4 py-1 hover:shadow-lg"
        >
          View
        </button>
      </div>
    </div>
  </div>
</template>

<script>
export default {
  props: {
    id: String,
    name: String,
    description: String,
    collaborators: String,
  },
  data() {
    return {
      description_formatted: "",
    };
  },
  methods: {
    toProject() {
      this.$router.push("/project/" + this.id);
    },
  },
  created() {
    console.log(this.description);
    this.description_formatted = this.description.replace("<br><br>", " ");
    console.log(this.description_formatted);
    if (this.description.length > 100) {
      let new_description = this.description_formatted.substr(0, 90);
      this.description_formatted = new_description + "...";
    }
  },
};
</script>
