<template>
  <Header></Header>

  <Modal />

  <div className="flex flex-col justify-center md:flex-row h-full">
    <div class="p-10">
      <Loading />
    </div>
  </div>
</template>

<script>
import Header from "@/components/shared/Header.vue";
import Modal from "@/components/TagModal.vue";
import Loading from "@/components/Shared/Loading.vue";

export default {
  components: { Header, Loading, Modal },
  data() {
    return {
      id: null,
    };
  },
  created() {
    this.id = localStorage.getItem("id");
  },
  methods: {},
};
</script>
